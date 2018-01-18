﻿namespace VeloEventsManager.Data
{
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	using VeloEventsManager.Models;

	public interface IVeloEventsManagerDbContext
	{
		IDbSet<Event> Events { get; set; }

		IDbSet<Route> Routes { get; set; }

		IDbSet<Point> Points { get; set; }

		IDbSet<Bike> Bikes { get; set; }

		IDbSet<EventDay> EventDays { get; set; }

		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
			where TEntity : class;

		void Dispose();

		int SaveChanges();
	}
}