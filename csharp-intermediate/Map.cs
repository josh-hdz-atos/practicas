using System;
using System.Text.RegularExpressions;

namespace csharp_intermediate {
  class Map<T> where T : Abstract
  {
    private T[] array;

    public Map(int size) { this.array = new T[size]; }

    public dynamic this[int i]
    {
      get { return this.array[i].value; }
      set { this.array[i] = value; }
    }

    public dynamic this[string key]
    {
      get
      {
        int pos = -1;

        for (int i = 0; i <this.array.Length; i++)
          if (this.array[i] != null)
            if (this.array[i].key == key)
              pos = i;
          else
            break;

        if (pos == -1)
          throw new ArgumentException($"Key '{key}' not found");

        return this.array[pos].value;
      }
      set
      {
        for (int i = 0; i < this.array.Length; i++)
          if (this.array[i] != null)
            if (this.array[i].key == key)
              this.array[i].value = value;
          else
            this.array[i] = value;
      }
    }
  }

  static public class MapExtenssion {
    internal static dynamic First<T>(this Map<T> array) where T : Abstract
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
