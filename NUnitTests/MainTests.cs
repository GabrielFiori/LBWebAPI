using Domain.Commands;
using FluentValidation.Results;
using MediatR;
using NUnit.Framework;

namespace NUnitTests
{
    public class MainTests
    {
        private readonly IMediator _mediator;

        public MainTests(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async void RegisterNewCommand()
        {
            RegisterNewBookCommand registerCommand = new RegisterNewBookCommand("Teste", 1);

            ValidationResult commandResult = await _mediator.Send(registerCommand);

            Assert.Pass();
        }
    }
}