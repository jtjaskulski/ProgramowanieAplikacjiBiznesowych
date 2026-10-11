// Typowana funkcja powitania
function greet(name: string): string {
  return `Cześć, ${name}!`;
}

// Wywołanie z poprawnym typem
const message = greet("TypeScript");
console.log(message);  // "Cześć, TypeScript!"

// Próba z niepoprawnym typem - BŁĄD KOMPILACJI!
// const wrongMessage = greet(123);
// Error: Argument of type 'number' is not assignable to parameter of type 'string'