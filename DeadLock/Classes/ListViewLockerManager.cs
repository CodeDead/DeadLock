using System.Collections.Generic;

namespace DeadLock.Classes
{
    internal class ListViewLockerManager
    {
        private readonly List<ListViewLocker> _listViewLockers;

        internal ListViewLockerManager()
        {
            _listViewLockers = new List<ListViewLocker>();
        }

        internal void AddListViewLocker(ListViewLocker lvl)
        {
            _listViewLockers.Add(lvl);
        }

        internal void DeleteListViewLocker(string path)
        {
            foreach (ListViewLocker lvl in _listViewLockers)
            {
                if (lvl.GetPath() != path) continue;
                _listViewLockers.Remove(lvl);
                break;
            }
        }

        private IEnumerable<ListViewLocker> GetListViewLockers()
        {
            return _listViewLockers;
        }

        internal ListViewLocker FindListViewLocker(string path)
        {
            foreach (ListViewLocker lvl in GetListViewLockers())
            {
                if (lvl.GetPath() == path) return lvl;
            }
            return null;
        }

        internal void CancelAllTasks()
        {
            foreach (ListViewLocker lvl in GetListViewLockers())
            {
                lvl.CancelTask();
            }
        }
    }
}
