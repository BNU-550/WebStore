using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;

namespace WebStore.Models
{
    public class ShoppingCart 
    {
       
        
            private readonly WebStoreDbContext _context;

            public ShoppingCart(WebStoreDbContext context)
            {
                _context = context;
            }

            string ShoppingCartId { get; set; }

            public const string CartSessionKey = "CartId";
            public static ShoppingCart GetCart(WebStoreDbContext context)
            {
                var cart = new ShoppingCart(context);

                return cart;

            }

         
            public void AddToCart(Phone phone)
            {
                var cartPhone = _context.Carts.SingleOrDefault(
                    c => c.CartId == ShoppingCartId
                    && c.PhoneId == phone.PhoneId);

                if (cartPhone == null)
                {
                    cartPhone = new Cart
                    {
                        PhoneId = phone.PhoneId,
                        CartId = ShoppingCartId,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    _context.Carts.Add(cartPhone);

                }
                else
                {
                    cartPhone.Count++;
                }

                _context.SaveChanges();
            }

            public int RemoveFromCart(int id)
            {

                var cartPhone = _context.Carts.Single(
                    cart => cart.CartId == ShoppingCartId
                    && cart.RecordId == id);

                int phoneCount = 0;

                if (cartPhone != null)
                {
                    if (cartPhone.Count > 1)
                    {
                        cartPhone.Count--;
                        phoneCount = cartPhone.Count;
                    }
                    else
                    {
                        _context.Carts.Remove(cartPhone);
                    }

                    _context.SaveChanges();
                }
                return phoneCount;
            }

            public void EmptyCart()
            {
                var cartPhones = _context.Carts.Where(
                    cart => cart.CartId == ShoppingCartId);

                foreach (var cartPhone in cartPhones)
                {
                    _context.Carts.Remove(cartPhone);
                }
                _context.SaveChanges();
            }

            public List<Cart> GetCartPhones()
            {
                return _context.Carts.Where(
                    cart => cart.CartId == ShoppingCartId).ToList();
            }

            public int GetCount()
            {
                int? count = (from cartPhones in _context.Carts
                              where cartPhones.CartId == ShoppingCartId
                              select (int?)cartPhones.Count).Sum();
                return count ?? 0;
            }

            public decimal GetTotal()
            {
                // Mutilpies phone price by phone count to get current price of each phone in the cart.
                decimal? total = (from cartPhones in _context.Carts
                                  where cartPhones.CartId == ShoppingCartId
                                  select (int?)cartPhones.Count *
                                  cartPhones.Phone.Price).Sum();

                return total ?? decimal.Zero;
            }

            public int CreateOrder(Order order)
            {
                decimal orderTotal = 0;

                var cartPhones = GetCartPhones();

                foreach (var phone in cartPhones)
                {
                    var orderDetail = new OrderDetail
                    {
                        PhoneId = phone.PhoneId,
                        OrderId = order.OrderId,
                        UnitPrice = phone.Phone.Price,
                        Quantity = phone.Count
                    };

                    orderTotal += (phone.Count * phone.Phone.Price);

                    _context.OrderDetails.Add(orderDetail);

                }

                order.Total = orderTotal;


                _context.SaveChanges();

                EmptyCart();

                return order.OrderId;
            }

            public string GetCartId(HttpContext context)
            {
                if (context.Session.GetString(CartSessionKey) == null)
                {
                    if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                    {
                        context.Session.SetString(CartSessionKey,
                            context.User.Identity.Name);
                    }
                    else
                    {

                        Guid tempCartId = Guid.NewGuid();

                        context.Session.SetString(CartSessionKey, tempCartId.ToString());
                    }
                }
                return context.Session.GetString(CartSessionKey).ToString();
            }

            public void MigrateCart(string Email)
            {
                var shoppingCart = _context.Carts.Where(
                    c => c.CartId == ShoppingCartId);

                foreach (Cart phone in shoppingCart)
                {
                    phone.CartId = Email;
                }
                _context.SaveChanges();
            }
        }

        
    }
