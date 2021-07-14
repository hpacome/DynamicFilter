using DynamicFilter.Models;
using DynamicFilter.tests.Fake;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DynamicFilter.tests
{
    public class DynamicFilter_Int32_Tests
    {
        [Fact]
        public async Task Int32_equals_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 1, Value = 203 },
                    new ExempleInt32Entity() { Id = 2, Value = 200 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "equals",
                Value = "200"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task Int32_notEquals_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 3, Value = 293 },
                    new ExempleInt32Entity() { Id = 4, Value = 300 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "notEquals",
                Value = "293"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var expectedresult = _dbContext.ExempleStringEntities.Count() - 1;
            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(expectedresult, result.Count());
        }

        [Fact]
        public async Task Int32_lt_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 5, Value = -2 },
                    new ExempleInt32Entity() { Id = 6, Value = 200 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "lt",
                Value = "0"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task Int32_lte_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 7, Value = 0 },
                    new ExempleInt32Entity() { Id = 8, Value = 220 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "lte",
                Value = "0"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task Int32_gt_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 9, Value = 97 },
                    new ExempleInt32Entity() { Id = 10, Value = 1030 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "gt",
                Value = "1000"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task Int32_gte_Filter_Tests()
        {
            //Arrange  
            var options = new DbContextOptionsBuilder<Database1Context>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            var _dbContext = new Database1Context(options);

            await _dbContext.ExempleInt32Entities.AddRangeAsync(
                    new ExempleInt32Entity() { Id = 11, Value = 97 },
                    new ExempleInt32Entity() { Id = 12, Value = 1000 }
                );

            await _dbContext.SaveChangesAsync();

            //Act
            IList<FieldContrainte> fieldContraintes = new List<FieldContrainte>();
            List<Contrainte> contraintes = new List<Contrainte>();
            contraintes.Add(new Contrainte
            {
                MatchMode = "gte",
                Value = "1000"
            });
            fieldContraintes.Add(new FieldContrainte
            {
                FieldName = "Value",
                Operator = "or",
                Contraintes = contraintes
            });

            var result = _dbContext.ExempleInt32Entities.Filter(fieldContraintes);

            //Assert  
            Assert.Equal(1, result.Count());
        }
    }
}
