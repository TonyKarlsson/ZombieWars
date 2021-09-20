static bool isPrime(int num) {
  for (int i = 2; i < num; i++) {
    if (num % i == 0) {
      return false;
    } 
    else 
    {
      return num > 1;
    }
  }
}
