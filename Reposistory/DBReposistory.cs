using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BTTH8
{
    // Lớp cơ sở dùng chung các thao tác CRUD + transaction cho CategoryRepository, BookCopyRepository
    public abstract class DBRepository<T> where T : class
    {
        protected readonly QLTVDBContext _context;

        protected DBRepository() : this(new QLTVDBContext()) { }

        protected DBRepository(QLTVDBContext context)
        {
            _context = context;
        }

        // ===================== CRUD =====================
        public virtual List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public virtual T GetById(params object[] keys)
        {
            var e = _context.Set<T>().Find(keys);
            if (e != null) _context.Entry(e).State = EntityState.Detached;
            return e;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        // Thêm nhiều bản ghi: hoặc thành công hết, hoặc không thêm gì (transaction)
        public virtual void AddRange(IEnumerable<T> entities)
        {
            var list = entities.ToList();
            ExecuteInTransaction(() =>
            {
                _context.Set<T>().AddRange(list);
                Save();
            });
        }

        // Xóa nhiều bản ghi: hoặc xóa hết, hoặc không xóa gì (transaction)
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            var list = entities.ToList();
            ExecuteInTransaction(() =>
            {
                _context.Set<T>().RemoveRange(list);
                Save();
            });
        }

        // ===================== TRANSACTION =====================
        // Chạy "action" trong một transaction: không lỗi thì Commit, có lỗi thì Rollback rồi ném lại lỗi.
        // Nếu đang nằm trong một transaction khác thì tham gia luôn transaction đó (không tạo lồng).
        public void ExecuteInTransaction(Action action, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            if (_context.Database.CurrentTransaction != null)
            {
                action();
                return;
            }

            using (var tx = _context.Database.BeginTransaction(level))
            {
                try
                {
                    action();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    _context.ChangeTracker.Clear();   // bỏ các thay đổi còn dở trong bộ nhớ
                    throw;
                }
            }
        }

        // Bản có giá trị trả về
        public TResult ExecuteInTransaction<TResult>(Func<TResult> func, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            TResult result = default;
            ExecuteInTransaction(() => { result = func(); }, level);
            return result;
        }

        // Lưu xong thì xoá tracking để lần đọc sau luôn lấy dữ liệu mới, tránh xung đột key
        protected void Save()
        {
            try { _context.SaveChanges(); }
            finally { _context.ChangeTracker.Clear(); }
        }
    }
}