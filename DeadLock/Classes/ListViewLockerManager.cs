using System.Collections.Generic;

namespace DeadLock.Classes
{
    /// <summary>
    /// The ListViewLockerManager holds a collection of ListViewLockers and operations associated with those ListViewLockers.
    /// </summary>
    internal class ListViewLockerManager
    {
        private readonly List<ListViewLocker> _listViewLockers;

        /// <summary>
        /// Generates a new ListViewLockerManager.
        /// </summary>
        internal ListViewLockerManager()
        {
            _listViewLockers = new List<ListViewLocker>();
        }

        /// <summary>
        /// Add a new ListViewLocker to the collection of ListViewLockers.
        /// </summary>
        /// <param name="lvl">The new ListViewLocker that should be added.</param>
        internal void AddListViewLocker(ListViewLocker lvl)
        {
            _listViewLockers.Add(lvl);
        }

        /// <summary>
        /// Remove a ListViewLocker from the collection of ListViewLockers.
        /// </summary>
        /// <param name="lvl">The ListViewLocker that should be removed from the collection.</param>
        internal void DeleteListViewLocker(ListViewLocker lvl)
        {
            _listViewLockers.Remove(lvl);
        }

        /// <summary>
        /// Get all the ListViewLockers that are associated with the ListViewLockerManager.
        /// </summary>
        /// <returns>A list of ListViewLockers that are associated with the ListViewLockerManager.</returns>
        private IEnumerable<ListViewLocker> GetListViewLockers()
        {
            return _listViewLockers;
        }

        /// <summary>
        /// Finds the ListViewLocker that is associated with a path.
        /// </summary>
        /// <param name="path">The path that is supposidly associated with a ListViewLocker in the collection.</param>
        /// <returns>The ListViewLocker that is associated with the path.</returns>
        internal ListViewLocker FindListViewLocker(string path)
        {
            foreach (ListViewLocker lvl in GetListViewLockers())
            {
                if (lvl.GetPath() == path) return lvl;
            }
            return null;
        }

        /// <summary>
        /// Cancel all the tasks that are associated with the collection of ListViewLockers.
        /// </summary>
        internal void CancelAllTasks()
        {
            foreach (ListViewLocker lvl in GetListViewLockers())
            {
                lvl.CancelTask();
            }
        }
    }
}
