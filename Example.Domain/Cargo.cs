using System;
using System.Collections.Generic;
using System.Linq;
using Example.Core;

namespace Example.Domain
{
    public class Cargo
    {
        public Location Origin { get; }
        public Location Destination { get; }

        public DateTime ArrivalDeadline { get; }

        public TrackingId TrackingId { get; }

        private Cargo(Location origin, Location destination, DateTime arrivalDeadline)
        {
            Origin = origin;
            Destination = destination;
            ArrivalDeadline = arrivalDeadline;
            TrackingId = new TrackingId();
        }

        public static IResult Create(IResult originResult, IResult destinationResult, DateTime arrivalDeadline)
        {
            var arrivalDeadlineResult = (arrivalDeadline < DateTime.UtcNow)
                ? new Failure("Arrival deadline is in the past.")
                : new Success<DateTime>(arrivalDeadline) as IResult;
            
            var results = new List<IResult> { originResult, destinationResult, arrivalDeadlineResult };

            return (results.Any(r => r is Failure))
                ? Failure.Combine(results)
                : new Success<Cargo>(new Cargo(
                    ((Success<Location>) originResult).Result, 
                    ((Success<Location>) destinationResult).Result,
                    ((Success<DateTime>) arrivalDeadlineResult).Result)) as IResult;
        }
    }
}
