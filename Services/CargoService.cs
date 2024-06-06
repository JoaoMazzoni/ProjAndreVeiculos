using Repositories;

namespace Services
{
    public class CargoService
    {
        private CargoRepository cargoRepository;

        public CargoService()
        {
            cargoRepository = new CargoRepository();
        }

        public void InsertCargo()
        {
            cargoRepository.InsertCargo();
        }

    }
}
