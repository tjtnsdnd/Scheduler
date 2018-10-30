using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Data
{
    #region EntityData<T>
    public class EntityData<T> where T : class, new()
    {
        #region Context
        private static void PrintSQL(string sql)
        {
            Debug.WriteLine(sql);
        }

        protected DSMSEntities CreateContext()
        {
            var context = new DSMSEntities();
            context.Database.Log = PrintSQL;
            context.Configuration.ProxyCreationEnabled = false;

            return context;
        }
        #endregion

        // TODO:검토 요망

        #region Create
        /// <summary>
        ///     엔터티를 생성한다. string형 속성은 string.Empty 값으로 채우고, DateTime형 속성은 DateTime.Today 값으로 채운다.
        /// </summary>
        /// <returns>생성된 엔터티</returns>
        public virtual T Create()
        {
            return Create(string.Empty, DateTime.Today);
        }

        /// <summary>
        ///     엔터티를 생성한다. string형 속성은 string.Empty 값으로 채우고, DateTime형 속성은 기본 DateTime 값으로 채운다.
        /// </summary>
        /// <param name="defaultDateTime">기본 DateTime 값</param>
        /// <returns>생성된 엔터티</returns>
        public virtual T Create(DateTime defaultDateTime)
        {
            return Create(string.Empty, defaultDateTime);
        }

        /// <summary>
        ///     엔터티를 생성한다. string형 속성은 기본 string 값으로 채우고, DateTime형 속성은 기본 DateTime 값으로 채운다.
        /// </summary>
        /// <param name="defaultString">기본 string 값</param>
        /// <param name="defaultDateTime">기본 DateTime 값</param>
        /// <returns>생성된 엔터티</returns>
        public virtual T Create(string defaultString, DateTime defaultDateTime)
        {
            T entity = new T();
            //			entity.Clear(defaultString, defaultDateTime);

            return entity;
        }
        #endregion

        #region Get
        /// <summary>
        ///     모든 엔터티를 반환한다.
        /// </summary>
        /// <returns>엔터티의 리스트</returns>
        public virtual List<T> Get()
        {
            return Get<T>(null, null, false, 0, int.MaxValue);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 반환한다.
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>엔터티의 리스트</returns>
        public List<T> Get(Expression<Func<T, bool>> where)
        {
            return Get<T>(where, null, false, 0, int.MaxValue);
        }

        /// <summary>
        ///     모든 엔터티들을 정렬식에 따라 정렬한 후 반환한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <param name="ascending">true이면 오름차순, false이면 내림차순</param>
        /// <returns>엔터티의 리스트</returns>
        public List<T> Get<U>(Expression<Func<T, U>> orderBy, bool ascending)
        {
            return Get(null, orderBy, ascending, 0, int.MaxValue);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 반환한다. 페이징을 지원한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <param name="ascending">true이면 오름차순, false이면 내림차순</param>
        /// <param name="startRowIndex">반환할 엔터티의 시작 인덱스</param>
        /// <param name="maximumRows">반환할 엔터티의 갯수</param>
        /// <returns>엔터티의 리스트</returns>
        public List<T> Get<U>(Expression<Func<T, U>> orderBy, bool ascending, int startRowIndex, int maximumRows)
        {
            return Get(null, orderBy, ascending, startRowIndex, maximumRows);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 반환한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <param name="ascending">true이면 오름차순, false이면 내림차순</param>
        /// <returns>엔터티의 리스트</returns>
        public List<T> Get<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending)
        {
            return Get(where, orderBy, ascending, 0, int.MaxValue);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 반환한다. 페이징을 지원한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <param name="ascending">true이면 오름차순, false이면 내림차순</param>
        /// <param name="startRowIndex">반환할 엔터티의 시작 인덱스</param>
        /// <param name="maximumRows">반환할 엔터티의 갯수</param>
        /// <returns>엔터티의 리스트</returns>
        public List<T> Get<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending, int startRowIndex, int maximumRows)
        {
            using (var context = CreateContext())
            {
                return GetCore(where, orderBy, ascending, startRowIndex, maximumRows, context).ToList();
            }
        }
        #endregion

        #region select
        /// <summary>
        ///     모든 선택식의 결과를 반환한다.
        /// </summary>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public virtual List<R> Select<R>(Expression<Func<T, R>> select)
        {
            return Select<T, R>(null, null, false, 0, int.MaxValue, select);
        }

        /// <summary>
        ///     조건식에 맞는 선택식의 결과를 반환한다.
        /// </summary>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="where"> 조건식 </param>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public List<R> Select<R>(Expression<Func<T, bool>> where, Expression<Func<T, R>> select)
        {
            return Select<T, R>(where, null, false, 0, int.MaxValue, select);
        }

        /// <summary>
        ///     모든 엔터티들을 정렬식에 따라 정렬한 후 선택식의 결과를 반환한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U"> 정렬 기준이 되는 속성의 형식 </typeparam>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="orderBy"> 정렬식 </param>
        /// <param name="ascending"> true이면 오름차순, false이면 내림차순 </param>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public List<R> Select<U, R>(Expression<Func<T, U>> orderBy, bool ascending, Expression<Func<T, R>> select)
        {
            return Select(null, orderBy, ascending, 0, int.MaxValue, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 선택식의 결과를 반환한다. 페이징을 지원한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U"> 정렬 기준이 되는 속성의 형식 </typeparam>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="orderBy"> 정렬식 </param>
        /// <param name="ascending"> true이면 오름차순, false이면 내림차순 </param>
        /// <param name="startRowIndex"> 반환할 엔터티의 시작 인덱스 </param>
        /// <param name="maximumRows"> 반환할 엔터티의 갯수 </param>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public List<R> Select<U, R>(Expression<Func<T, U>> orderBy, bool ascending, int startRowIndex, int maximumRows, Expression<Func<T, R>> select)
        {
            return Select(null, orderBy, ascending, startRowIndex, maximumRows, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 선택식의 결과를 반환한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U"> 정렬 기준이 되는 속성의 형식 </typeparam>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="where"> 조건식 </param>
        /// <param name="orderBy"> 정렬식 </param>
        /// <param name="ascending"> true이면 오름차순, false이면 내림차순 </param>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public List<R> Select<U, R>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending, Expression<Func<T, R>> select)
        {
            return Select(where, orderBy, ascending, 0, int.MaxValue, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티들을 정렬식에 따라 정렬한 후 선택식의 결과를 반환한다. 페이징과 프로젝션을을 지원한다. 제네릭 메서드이므로 ObjectDataSource에서는 사용할 수 없다.
        /// </summary>
        /// <typeparam name="U"> 정렬 기준이 되는 속성의 형식 </typeparam>
        /// <typeparam name="R"> 선택 형식 </typeparam>
        /// <param name="where"> 조건식 </param>
        /// <param name="orderBy"> 정렬식 </param>
        /// <param name="ascending"> true이면 오름차순, false이면 내림차순 </param>
        /// <param name="startRowIndex"> 반환할 엔터티의 시작 인덱스 </param>
        /// <param name="maximumRows"> 반환할 엔터티의 갯수 </param>
        /// <param name="select"> 선택식 </param>
        /// <returns> 엔터티의 리스트 </returns>
        public List<R> Select<U, R>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending, int startRowIndex, int maximumRows, Expression<Func<T, R>> select)
        {
            using (var context = CreateContext())
            {
                var query = GetCore(where, orderBy, ascending, startRowIndex, maximumRows, context);
                return query.Select(select).ToList();
            }
        }

        private static IQueryable<T> GetCore<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending, int startRowIndex, int maximumRows, DbContext context)
        {
            var query = from x in context.Set<T>()
                        select x;

            if (where != null)
                query = query.Where(where);

            IOrderedQueryable<T> orderedQuery = null;

            if (orderBy != null)
                orderedQuery = (ascending) ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            if (startRowIndex != 0 || maximumRows != int.MaxValue)
            {
                if (orderedQuery != null)
                    orderedQuery = (IOrderedQueryable<T>)orderedQuery.Skip(startRowIndex).Take(maximumRows);
                else
                    query = query.Skip(startRowIndex).Take(maximumRows);
            }

            return orderedQuery ?? query;
        }
        #endregion

        #region GetSingle
        /// <summary>
        ///     조건식에 맞는 엔터티를 구한다. 조건식에 맞는 엔터티가 없으면 null이 반환되고 둘 이상이면 예외가 발생한다.
        /// </summary>
        /// <param name="where">조건식. 일반적으로 PK가 지정되어야 한다.</param>
        /// <returns>엔터티</returns>
        public T GetSingle(Expression<Func<T, bool>> where)
        {
            using (var context = CreateContext())
            {
                return context.Set<T>().SingleOrDefault(where);
            }
        }
        #endregion

        #region GetFirst / GetLast
        /// <summary>
        ///     모든 엔터티 중 첫번째 엔터티를 반환한다. 엔터티의 순서는 DB에 의해 결정된다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <returns>엔터티</returns>
        public virtual T GetFirst()
        {
            return GetFirst<T>(null, null);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티 중 첫번째 엔터티를 반환한다. 엔터티의 순서는 DB에 의해 결정된다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>엔터티</returns>
        public T GetFirst(Expression<Func<T, bool>> where)
        {
            return GetFirst<T>(where, null);
        }

        /// <summary>
        ///     모든 엔터티를 정렬식에 따라 정렬했을 때 첫번째 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <returns>엔터티</returns>
        public T GetFirst<U>(Expression<Func<T, U>> orderBy)
        {
            return GetFirst(null, orderBy);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티를 정렬식에 따라 정렬했을 때 첫번째 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <returns>엔터티</returns>
        public T GetFirst<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy)
        {
            return GetFirstCore(where, orderBy, true);
        }

        private T GetFirstCore<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending)
        {
            using (var context = CreateContext())
            {
                return QueryFirst(where, orderBy, ascending, context).FirstOrDefault();
            }
        }

        /// <summary>
        ///     모든 엔터티를 정렬식에 따라 정렬했을 때 마지막 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <returns>엔터티</returns>
        public T GetLast<U>(Expression<Func<T, U>> orderBy)
        {
            return GetLast(null, orderBy);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티를 정렬식에 따라 정렬했을 때 마지막 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <returns>엔터티</returns>
        public T GetLast<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy)
        {
            return GetFirstCore(where, orderBy, false);
        }

        private static IQueryable<T> QueryFirst<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, bool ascending, DbContext context)
        {
            var query = from x in context.Set<T>()
                        select x;

            if (where != null)
                query = query.Where(where);

            // 마지막 행은 orderby가 반드시 지정되어 있어야 함. orderby를 지정하지 않으면 skip 메서드를 사용할 수 없기 때문.
            if (orderBy != null)
                query = @ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            return query;
        }
        #endregion

        #region SelectFirst / SelectLast
        /// <summary>
        ///     모든 엔터티 중 첫번째 엔터티를 반환한다. 엔터티의 순서는 DB에 의해 결정된다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public virtual R SelectFirst<R>(Expression<Func<T, R>> select)
        {
            return SelectFirst<T, R>(null, null, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티 중 첫번째 엔터티를 반환한다. 엔터티의 순서는 DB에 의해 결정된다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public R SelectFirst<R>(Expression<Func<T, bool>> where, Expression<Func<T, R>> select)
        {
            return SelectFirst<T, R>(where, null, select);
        }

        /// <summary>
        ///     모든 엔터티를 정렬식에 따라 정렬했을 때 첫번째 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public R SelectFirst<U, R>(Expression<Func<T, U>> orderBy, Expression<Func<T, R>> select)
        {
            return SelectFirst(null, orderBy, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티를 정렬식에 따라 정렬했을 때 첫번째 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public R SelectFirst<U, R>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, Expression<Func<T, R>> select)
        {
            return SelectFirstCore(where, orderBy, select, true);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티를 정렬식에 따라 정렬했을 때 첫번째 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <param name="select">선택식</param>
        /// <param name="ascending">true이면 오름차순, false이면 내림차순</param>
        /// <returns>엔터티</returns>
        private R SelectFirstCore<U, R>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, Expression<Func<T, R>> select, bool ascending)
        {
            using (var context = CreateContext())
            {
                var query = QueryFirst(where, orderBy, ascending, context);
                return query.Select(select).FirstOrDefault();
            }
        }

        /// <summary>
        ///     모든 엔터티를 정렬식에 따라 정렬했을 때 마지막 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="orderBy">정렬식</param>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public R SelectLast<U, R>(Expression<Func<T, U>> orderBy, Expression<Func<T, R>> select)
        {
            return SelectLast(null, orderBy, select);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티를 정렬식에 따라 정렬했을 때 마지막 엔터티를 반환한다. 조건식에 맞는 엔터티가 없으면 null이 반환된다.
        /// </summary>
        /// <typeparam name="U">정렬 기준이 되는 속성의 형식</typeparam>
        /// <typeparam name="R">선택 형식</typeparam>
        /// <param name="where">조건식</param>
        /// <param name="orderBy">정렬식</param>
        /// <param name="select">선택식</param>
        /// <returns>엔터티</returns>
        public R SelectLast<U, R>(Expression<Func<T, bool>> where, Expression<Func<T, U>> orderBy, Expression<Func<T, R>> select)
        {
            return SelectFirstCore(where, orderBy, select, false);
        }
        #endregion

        #region GetCount
        /// <summary>
        ///     모든 엔터티의 갯수를 구한다.
        /// </summary>
        /// <returns>엔터티의 갯수</returns>
        public virtual int GetCount()
        {
            return GetCount(null);
        }

        /// <summary>
        ///     조건식에 맞는 엔터티의 갯수를 구한다.
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>엔터티의 갯수</returns>
        public int GetCount(Expression<Func<T, bool>> where)
        {
            using (var context = CreateContext())
            {
                var query = from item in context.Set<T>()
                            select item;

                if (where != null)
                    query = query.Where(where);

                return query.Count();
            }
        }
        #endregion

        #region Exist
        /// <summary>
        ///     조건식에 맞는 엔터티가 존재하는지 검사한다.
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>존재 여부</returns>
        public bool Exists(Expression<Func<T, bool>> where)
        {
            using (var context = CreateContext())
            {
                var query = from item in context.Set<T>()
                            select item;

                if (where != null)
                    query = query.Where(where);

                return query.Any();
            }
        }
        #endregion

        #region Insert / Update / Delete
        /// <summary>
        ///     엔터티를 삽입한다.
        /// </summary>
        /// <param name="entity">삽입할 엔터티</param>
        /// <returns>삽입된 엔터티</returns>
        public virtual T Insert(T entity)
        {
            using (var context = CreateContext())
            {
                MarkToInsert(context, entity);

                context.SaveChanges();

                return entity;
            }
        }

        internal virtual void MarkToInsert(DbContext context, T entity)
        {
            ClearNavigationProperties(entity);

            context.Set<T>().Add(entity);
        }

        /// <summary>
        ///     엔터티 컬렉션을 삽입한다.
        /// </summary>
        /// <param name="entities">삽입할 엔터티가 포함된 컬렉션</param>
        /// <returns>예외 메시지. 성공이면 null</returns>
        public virtual string InsertMany(List<T> entities)
        {
            using (var context = CreateContext())
            {
                MarkToInsertMany(context, entities);

                context.SaveChanges();

                return null;
            }
        }

        internal virtual void MarkToInsertMany(DbContext context, List<T> entities)
        {
            ClearNavigationProperties(entities);

            foreach (var entity in entities)
                context.Set<T>().Add(entity);
        }

        /// <summary>
        ///     엔터티를 갱신한다.
        /// </summary>
        /// <param name="entity">갱신할 엔터티</param>
        public virtual void Update(T entity)
        {
            using (var context = CreateContext())
            {
                MarkToUpdate(context, entity);

                context.SaveChanges();
            }
        }

        internal virtual void MarkToUpdate(DbContext context, T entity)
        {
            ClearNavigationProperties(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     엔터티 컬렉션을 갱신한다.
        /// </summary>
        /// <param name="entities">갱신할 엔터티가 포함된 컬렉션</param>
        public virtual void UpdateMany(List<T> entities)
        {
            using (var context = CreateContext())
            {
                MarkToUpdateMany(context, entities);

                context.SaveChanges();
            }
        }

        internal virtual void MarkToUpdateMany(DbContext context, List<T> entities)
        {
            ClearNavigationProperties(entities);

            foreach (var entity in entities)
                context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     엔터티를 삭제한다.
        /// </summary>
        /// <param name="entity">삭제할 엔터티</param>
        public virtual void Delete(T entity)
        {
            using (var context = CreateContext())
            {
                MarkToDelete(context, entity);

                context.SaveChanges();
            }
        }

        internal virtual void MarkToDelete(DbContext context, T entity)
        {
            //            Album album = (Album) entity;
            //            album.Artist = null;
            //            album.Tracks = null;
            ClearNavigationProperties(entity);

            context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        ///     엔터티 컬렉션을 삭제한다.
        /// </summary>
        /// <param name="entities">삭제할 엔터티 컬렉션</param>
        public virtual void DeleteMany(List<T> entities)
        {
            using (var context = CreateContext())
            {
                MarkToDeleteMany(context, entities);

                context.SaveChanges();
            }
        }

        internal virtual void MarkToDeleteMany(DbContext context, List<T> entities)
        {
            ClearNavigationProperties(entities);

            foreach (var entity in entities)
                context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        ///     조건식을 만족하는 엔터티들을 삭제한다.
        /// </summary>
        /// <param name="where">조건식</param>
        public virtual void DeleteAll(Expression<Func<T, bool>> where)
        {
            using (var context = CreateContext())
            {
                var query = from item in context.Set<T>()
                            select item;

                if (where != null)
                    query = query.Where(where);

                var entities = query.ToList();

                MarkToDeleteMany(context, entities);

                context.SaveChanges();
            }
        }
        #endregion

        #region helper methods
        /// <summary>
        ///     Navigation Property를 null로 설정한다. Navigation Property 와 Foreign Key가 모두 설정되면 [참조 무결성 제약 조건 위반이 발생했습니다. 참조 제약 조건을
        ///     정의하는 속성 값이 관계의 주 개체와 종속 개체 간에 일치하지 않습니다.] 예외가 발생함.
        /// </summary>
        /// <param name="entities"></param>
        protected void ClearNavigationProperties(List<T> entities)
        {
            if (entities.Count == 0)
                return;

            var propertyInfoes = GetNavigationProperties(entities[0].GetType());

            foreach (var propertyInfo in propertyInfoes)
                foreach (var entity in entities)
                    propertyInfo.SetValue(entity, null, null);
        }

        /// <summary>
        ///     Navigation Property를 null로 설정한다. Navigation Property 와 Foreign Key가 모두 설정되면 [참조 무결성 제약 조건 위반이 발생했습니다. 참조 제약 조건을
        ///     정의하는 속성 값이 관계의 주 개체와 종속 개체 간에 일치하지 않습니다.] 예외가 발생함.
        /// </summary>
        /// <param name="entity"></param>
        protected void ClearNavigationProperties(T entity)
        {
            List<PropertyInfo> propertyInfoes = GetNavigationProperties(entity.GetType());

            foreach (var propertyInfo in propertyInfoes)
                propertyInfo.SetValue(entity, null, null);
        }

        protected static List<PropertyInfo> GetNavigationProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead && x.CanWrite &&
                            x.PropertyType.IsClass && x.GetGetMethod().IsVirtual && x.PropertyType.Name != "String")
                .ToList();
        }
        #endregion
    }
    #endregion
}
