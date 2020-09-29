namespace MusicApplication.Data.Interfaces
{
    public interface IShoppingCartService
    {
        void AddItemToCart(int cartId, int albumId, int amount);
        void RemoveItemFromCart(int cartId, int albumId);

    }
}
