using Repositories;

namespace Services
{
    public class CarroService
    {
        private CarroRepository carroRepository;

        public CarroService()
        {
            carroRepository = new CarroRepository();
        }


        public void InsertCarro()
        {
            carroRepository.InsertCarro();
        }


    }
}
