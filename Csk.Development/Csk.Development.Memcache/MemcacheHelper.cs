using Memcached.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.Memcache
{
  public  class MemcacheHelper
    {
      private readonly static MemcachedClient mc = null;
      static MemcacheHelper()
      {
          string[] serverlist = { "192.168.142.139:11211", "10.0.0.132:11211" };   
          //初始化池
          SockIOPool pool = SockIOPool.GetInstance();
          pool.SetServers(serverlist);
          pool.InitConnections = 3;
          pool.MinConnections = 3;
          pool.MaxConnections = 5;
          pool.SocketConnectTimeout = 1000;
          pool.SocketTimeout = 3000;
          pool.MaintenanceSleep = 30;
          pool.Failover = true;
          pool.Nagle = false;
          pool.Initialize();
          // 获得客户端实例
          mc = new MemcachedClient();
          mc.EnableCompression = false;
      }
      /// <summary>
      /// 从缓存中取出值
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      public static object Get(string key)
      {
          return mc.Get(key);
      }
      /// <summary>
      /// 向缓存中存储数据
      /// </summary>
      /// <param name="key"></param>
      /// <param name="value"></param>
      public static void Set(string key, object value)
      {
          mc.Set(key, value);
      }
      public static void Set(string key, object value,DateTime time)
      {
          mc.Set(key, value,time);
      }
      public static bool Delete(string key)
      {
          if (mc.KeyExists(key))
          {
              return mc.Delete(key);
          }
          return false;
      }
    }
}
