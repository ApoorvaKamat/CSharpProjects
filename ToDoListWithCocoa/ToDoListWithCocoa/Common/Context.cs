using System;
using System.Collections.Generic;
namespace ToDoListWithCocoa
{
    /// <summary>
    /// Set the Context for the Entire Project to use
    /// All Properties declared must be public.
    /// All Properties can be used globally
    /// </summary>
    public static class Context
    {
        public static bool IsAnyRowDeleted { get; set; } = false;
    }
}
