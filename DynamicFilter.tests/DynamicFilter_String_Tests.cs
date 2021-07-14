using DynamicFilter.Models;
using DynamicFilter.tests.Fake;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DynamicFilter.tests
{
    public class DynamicFilter_String_Tests
    {
        [Fact]
        public async Task String_startsWith_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 1, Value = "ceci est un exemple de start with" },
                    new ExempleStringEntity() { Id = 2, Value = "startwith 2 eme exemple de " }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "startsWith",
                Value = "startwith 2 eme"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task String_contains_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 3, Value = "ceci est un exemple de contains" },
                    new ExempleStringEntity() { Id = 4, Value = "contains 2 eme exemple" }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "contains",
                Value = "ins 2 eme ex"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task String_notContains_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 5, Value = "ceci est un exemple de notContains" },
                    new ExempleStringEntity() { Id = 6, Value = "notContains 2 eme ex" }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "notContains",
                Value = "exemple"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task String_endsWith_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 7, Value = "ceci est un exemple de endsWith" },
                    new ExempleStringEntity() { Id = 8, Value = "2 eme exemple avec endsWith" }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "endsWith",
                Value = "avec endsWith"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task String_equals_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 9, Value = "ceci est un exemple de equals" },
                    new ExempleStringEntity() { Id = 10, Value = "2 eme exemple avec equals" }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "equals",
                Value = "2 eme exemple avec equals"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task String_notEquals_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleStringEntities.AddRangeAsync(
                    new ExempleStringEntity() { Id = 11, Value = "ceci est un exemple de notEquals" },
                    new ExempleStringEntity() { Id = 12, Value = "2 eme exemple avec notEquals" }
                );
            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "notEquals",
                Value = "2 eme exemple avec notEquals"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var expectedresult = _dbContext.ExempleStringEntities.Count()-1;
            var result = _dbContext.ExempleStringEntities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(expectedresult, result.Count());
        }
    }
}
