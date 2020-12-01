using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Interfaces;
using WebTecnologyProjectApi.CQRS.Commands;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class ClearBasketCommandHandler: IRequestHandler<ClearBasketCommand>
    {
        private readonly IBasketService basketService;

        public ClearBasketCommandHandler(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        public async Task<Unit> Handle(ClearBasketCommand request, CancellationToken cancellationToken)
        {
            await basketService.RemoveAllBasketItemsAsync();
            return Unit.Value;
             
        }
    }
}
