using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using UnitTestingAPI.Infrastructure.Persistence;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;

namespace UnitTestingAPI.UnitTests.Application.Products.Commands.DeleteProduct;

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