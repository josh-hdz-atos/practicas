namespace csharp_intermediate {
  abstract class AbstractMap {
    public string key;
    public dynamic value;
  }

  class derived : AbstractMap{
    public derived(string key, dynamic value) {
      this.key = key;
      this.value = value;
    }
  }
}


