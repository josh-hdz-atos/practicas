using System;
using System.Text.RegularExpressions;

namespace csharp_intermediate {
  class Map<T> where T : AbstractMap
  {
    private T[] array = new T[100];

    public T this[int i]
    {
      get { return array[i]; }
      set { array[i] = value; }
    }

    public T this[string key]
    {
      get
      {
        var i = IndexOf<T>(array, key);
        throw new ArgumentException($"Key '{key}' not found"); 
      }
      set
      {
        for (int i = 0; i < 100; i++)
        {
          if (array[i] != null)
          {
            if (array[i].key == key)
            {
              array[i].value = value;
            }
          }
          else
          {
            array[i] = value;
          }
        }
      }
    }
  }

  static public class MapExtenssion {
    internal static T First<T>(this Map<T> array) where T :AbstractMap
    {
      return array[0];
    }

    internal static bool ValidKey(this string key) 
    {
      Regex expression = new Regex("[A-Z][a-z]{3}[0-9]{4}"); 
      if (expression.IsMatch(key))
      {
         return true; 
      }

      return false;
    }
  }
}
