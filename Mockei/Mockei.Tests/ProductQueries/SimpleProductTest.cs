using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockei.Context;
using Mockei.Entities;
using Moq;

namespace Mockei.Tests.ProductQueries
{
    [TestClass]
    public class SimpleProductTest
    {
        [TestMethod]
        public void GetOneProductMocking()
        {
            var mockDb = new Mock<IDbContext>();

            var list = new List<Product>();
            list.Add(new SimpleProduct() {Amount = 5, Name = "Pedra", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 15, Name = "Café", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 25, Name = "Dragão Branco de Olhos Azuis", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 52, Name = "Tesoura", ProductId = Guid.NewGuid()});

            var queryable = list.AsQueryable();

            var productMock = new Mock<DbSet<Product>>();
            productMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryable.Provider);
            productMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryable.Expression);
            productMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            productMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            mockDb.Setup(x => x.Set<Product>()).Returns(productMock.Object);

            var db = mockDb.Object;

            Assert.AreEqual(4, db.Set<Product>().Count());
        }
    }
}
