//系统包
using System;
//本地项目包
using RayPI.Infrastructure.Auth.Models;
using RayPI.Infrastructure.Treasury.Interfaces;

namespace RayPI.Infrastructure.Auth.Operate
{
    public class OperateSetter : IEntityBaseAutoSetter
    {
        private readonly IOperateInfo _operateInfo;

        public OperateSetter(IOperateInfo operateInfo)
        {
            _operateInfo = operateInfo;
        }

        /// <summary>创建人姓名</summary>
        /// <value>The name of the create.</value>
        public string CreateName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_operateInfo?.Uname))
                    return string.Empty;
                return _operateInfo?.Uname;

            }
        }

        /// <summary>创建人Id</summary>
        /// <value>The create identifier.</value>
        public long CreateId => _operateInfo?.Uid ?? -1L;

        /// <summary>创建时间</summary>
        /// <value>The create time.</value>
        public DateTime CreateTime => DateTime.Now;

        /// <summary>更新人姓名</summary>
        /// <value>The name of the update.</value>
        public string UpdateName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_operateInfo?.Uname))
                    return string.Empty;
                return _operateInfo?.Uname;
            }
        }

        /// <summary>更新人Id</summary>
        /// <value>The update identifier.</value>
        public long UpdateId => this._operateInfo?.Uid ?? -1L;

        /// <summary>更新时间</summary>
        /// <value>The update time.</value>
        public DateTime UpdateTime => DateTime.Now;
    }
}
