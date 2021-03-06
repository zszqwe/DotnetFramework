﻿using System;
using System.Collections.Generic;

namespace Dotnet.Configurations
{
    public class BackgroundWorkerConfiguration
    {
        /// <summary>后台定时任务的类型
        /// </summary>
        private List<Type> BackgroundWorkTypies = new List<Type>();

        /// <summary>添加类型
        /// </summary>
        public void AddWorkerType(Type type)
        {
            if (!BackgroundWorkTypies.Contains(type))
            {
                BackgroundWorkTypies.Add(type);
            }
        }

        /// <summary>获取注册的全部类型
        /// </summary>
        public List<Type> GetWorkerTypies()
        {
            return BackgroundWorkTypies;
        }

    }
}
