using System;
using Example.Core;
using Example.Domain;

namespace Example.Application
{
    public class BookCargoCommand
    {
        public string OriginUnLocode { get; set; }
        public string DestinationUnLocode { get; set; }

        public DateTime ArrivalDeadline { get; set; }

        public class Handler
        {
            private readonly ILocationRepository locationRepository;
            private readonly ICargoRepository cargoRepository;

            public Handler(ILocationRepository locationRepository, ICargoRepository cargoRepository)
            {
                this.locationRepository = locationRepository;
                this.cargoRepository = cargoRepository;
            }

            public IResult Execute(BookCargoCommand command)
            {
                switch (CreateCargo())
                {
                    case Failure failure :
                        return failure;
                    case Success<Cargo> success :
                        return StoreCargo(success.Result);
                    case var result :
                        throw new InvalidResultException(result);
                }

                IResult CreateCargo()
                {
                    return Cargo.Create(
                        locationRepository.Find(command.OriginUnLocode), 
                        locationRepository.Find(command.DestinationUnLocode), 
                        command.ArrivalDeadline
                    );
                }
                
                Success<string> StoreCargo(Cargo cargo)
                {
                    cargoRepository.Store(cargo);
                    
                    return new Success<string>(cargo.TrackingId.Value);
                }
            }
        }
    }
}