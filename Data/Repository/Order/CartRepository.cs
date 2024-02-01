using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Item;
using Repository.Interface.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Order
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(PotShopIDbContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Cart>();
        }
        private readonly DbSet<Cart> _table;


        public async Task SaveOrUpdate(Cart cart)
        {
            if (cart.Id == 0)
            {
                _table.Add(cart);
            }
            else
            {
                _table.Update(cart);
            }
            await _idbcontext.SaveChangesAsync();
        }

        public async Task<List<CartItem>> AddOrUpdateItemInCart(int userId, CartItem newItem)
        {
            Entity.Model.User user = await _idbcontext.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Items)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                if (user.Cart == null)
                {
                    user.Cart = new Cart();
                }

                CartItem existingItem = user.Cart.Items.SingleOrDefault(i => i.ItemId == newItem.ItemId);

                if (existingItem != null)
                {
                    existingItem.Quantity += newItem.Quantity;
                }
                else
                {
                    user.Cart.Items.Add(newItem);
                }

                await _idbcontext.SaveChangesAsync();

                // Retourne la liste complète des éléments du panier après l'ajout ou la mise à jour
                return user.Cart.Items.ToList();
            }

            // Retourne une liste vide si l'utilisateur n'a pas été trouvé
            return new List<CartItem>();
        }

        public async Task<List<CartItem>> GetCartItemsForUser(int userId)
        {
            Entity.Model.User user = await _idbcontext.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Items)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user != null && user.Cart != null)
            {
                return user.Cart.Items.ToList();
            }

            return new List<CartItem>();
        }

        public async Task<List<CartItem>> RemoveItemFromCart(int userId, int itemId)
        {
            Entity.Model.User user = await _idbcontext.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Items)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user != null && user.Cart != null)
            {
                CartItem itemToRemove = user.Cart.Items.SingleOrDefault(i => i.ItemId == itemId);

                if (itemToRemove != null)
                {
                    user.Cart.Items.Remove(itemToRemove);

                    await _idbcontext.SaveChangesAsync();
                }
            }

            return user?.Cart?.Items.ToList() ?? new List<CartItem>();
        }


            public async Task<List<CartItem>> UpdateCartItemQuantity(int userId, int itemId, int newQuantity)
            {
                // Rechercher l'utilisateur avec le panier dans la base de données
                Entity.Model.User user = await _idbcontext.Users
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Items)
                    .SingleOrDefaultAsync(u => u.Id == userId);

                if (user != null && user.Cart != null)
                {
                    // Rechercher l'article dans le panier
                    CartItem cartItem = user.Cart.Items.SingleOrDefault(item => item.ItemId == itemId);

                    if (cartItem != null)
                    {
                        // Mettre à jour la quantité de l'article dans le panier
                        cartItem.Quantity = newQuantity;

                        // Mettre à jour la base de données
                        await _idbcontext.SaveChangesAsync();
                    }
                }

                // Retourner la liste complète des éléments du panier après la mise à jour
                return user?.Cart?.Items.ToList() ?? new List<CartItem>();
            }
        }




    }

