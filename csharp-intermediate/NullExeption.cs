using System;

namespace csharp_intermediate {
  class NullExeption : NullReferenceException {
    public NullExeption(string message) : base(message) {
    }
  }
}
