using System;
using System.Collections.Generic;

namespace SmartSorting.Tests.Extensions
{
    public class TodoItem : IComparable<TodoItem>
    {
        public int Id { get; private set; }

        public TodoItem(int id)
        {
            this.Id = id;
        }

        public int CompareTo(TodoItem other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}