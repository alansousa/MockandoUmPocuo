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
            
            //Crio a instancia do Mock para a interface do contexto de banco de dados com base no Entity Framework
            var mockDb = new Mock<IDbContext>();

            //Crio uma lista que é o cenário para o meu Teste
            var list = new List<Product>();
            list.Add(new SimpleProduct() {Amount = 5, Name = "Pedra", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 15, Name = "Café", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 25, Name = "Dragão Branco de Olhos Azuis", ProductId = Guid.NewGuid()});
            list.Add(new SimpleProduct() {Amount = 52, Name = "Tesoura", ProductId = Guid.NewGuid()});

            //Transformar a lista em IQueryable é a forma de setá-la no DbSet posteriormente
            var queryable = list.AsQueryable();

            //Instancio o mock de DbSet que será injetado no mock do Context
            var productMock = new Mock<DbSet<Product>>();
            productMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryable.Provider);
            productMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryable.Expression);
            productMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            productMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //Seta o objeto do Mock anterior (o mock do dbSet) a chamada do metodo Set
            mockDb.Setup(x => x.Set<Product>()).Returns(productMock.Object);

            //Pega o objeto mockado
            var db = mockDb.Object;

            //testa o objeto mockado
            Assert.AreEqual(4, db.Set<Product>().Count());
        }
    }
}
