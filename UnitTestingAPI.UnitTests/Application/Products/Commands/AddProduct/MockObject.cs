using AutoFixture;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Infrastructure.Persistence;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;

namespace UnitTestingAPI.UnitTests.Application.Products.Commands.AddProduct;

internal class MockObject
{
	public MockObject()
	{
		var options = new DbContextOptionsBuilder<DatabaseContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;

		ApplicationContext = new DatabaseContext(options);

		Fixture = new();
	}

	public IDatabaseContext ApplicationContext { get; set; }

	public Fixture Fixture { get; set; }
}