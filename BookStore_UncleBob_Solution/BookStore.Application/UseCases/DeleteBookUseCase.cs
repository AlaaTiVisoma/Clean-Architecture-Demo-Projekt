using BookStore.Core.Interfaces;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class DeleteBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
