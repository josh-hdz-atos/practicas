namespace csharp_intermediate {
  abstract class Abstract {
    public string key;
    public dynamic value;
  }

  class derived : Abstract{
    public derived(string key, dynamic value) {
      this.key = key;
      this.value = value;
    }
  }
}


