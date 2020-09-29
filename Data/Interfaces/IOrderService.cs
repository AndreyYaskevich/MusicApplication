namespace MusicApplication.Data.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(int[] cartItemIds, int userId);
    }
}
