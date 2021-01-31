using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            for(var i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email($@"aluno_{i}@email.com"),
                    null
                ));
            }
        }

        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().FirstOrDefault(exp);

            Assert.Null(student);
        }

        [Fact]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().FirstOrDefault(exp);

            Assert.NotNull(student);
        }
    }
}