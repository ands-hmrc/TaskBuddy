using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

#nullable enable

namespace TaskBuddy.Data;
public interface IHasKey<TKey> {
	TKey Key { get; }
}

public class TaskItem : IHasKey<Guid> {
	public TaskItem( string name, string? description = null, params string[] categoryNames ) {
		Name = name;
		Description = description ?? string.Empty;
		Categories = categoryNames?.ToList() ?? [];
	}

	public TaskItem() { Name = string.Empty; Description = string.Empty; Categories = []; }
		
	public Guid Key { get; } = default;
	public string Name { get; }
	public string Description { get; }
	public bool IsChecked { get; set; }
	public ICollection<string> Categories { get; }
}

public interface IDataAccessProvider<T, TKey> where T : IHasKey<TKey>, new() where TKey : notnull {

	IReadOnlyList<T> GetAll();
	T GetItem( TKey key );
	bool UpdateItem( T item );
	bool DeleteItem( TKey key );
	T NewItem();
}

public class DataAccessProvider<T, TKey> : IDataAccessProvider<T, TKey> where T : IHasKey<TKey>, new() where TKey : notnull {
	protected List<T> _items = [];
	public T GetItem( TKey key ) =>  _items.FirstOrDefault( t => t.Key.Equals(key) );
	public T NewItem() => new();
	public bool UpdateItem( T item ) {
		try {
			var index = _items.FindIndex( i => i.Key.Equals( item.Key ));
			if ( index == -1 ) throw new ArgumentException( $"{typeof(T).Name} not found" );
			_items[ index ] = item;
			return true;
		}
		catch {
			throw;
		}
	}
	public bool DeleteItem( TKey key ) {
		throw new NotImplementedException();
	}
	public IReadOnlyList<T> GetAll() => _items;
}

public class TaskProvider : DataAccessProvider<TaskItem, Guid> {
	public TaskProvider() {
		_items = [
			new ("Task 1","Do task 1", "Important"),
			new ("Task 2","Do task 2", "Not Important"),
			new ("Task 3","Do task 3", "Stuff...") ];
	}
}
