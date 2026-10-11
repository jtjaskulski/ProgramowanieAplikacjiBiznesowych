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

// Jawna deklaracja typu
let firstName: string = "Anna";
let lastName: string = 'Kowalska';

// Template literals (backticks)
let fullName: string = `${firstName} ${lastName}`;

// Inferencja typu - TypeScript sam wywnioskuje typ
let city = "Warszawa";  // TypeScript wie że to string
// ❌ Błąd - nie możesz przypisać number do string
// firstName = 123;
// Error: Type 'number' is not assignable to type 'string'

// Wszystkie liczby to "number" (int, float, hex, binary)
let age: number = 25;
let price: number = 19.99;
let hex: number = 0xf00d;       // Hexadecimal = 61453
let binary: number = 0b1010;    // Binary = 10
let octal: number = 0o744;      // Octal = 484

console.log(binary);  // 10

// ❌ Błąd
// let wrongAge: number = "dwadzieścia pięć";
// let wrongAge: number = "0o744"; // ❌ Błąd - nie można przypisać string do number
let isActive: boolean = true;
let hasError: boolean = false;

// Wyniki operacji logicznych
let isAdult: boolean = age >= 18;  // true

// ❌ Błąd - "true" jako string to NIE boolean
// isActive = "true";
// Error: Type 'string' is not assignable to type 'boolean'

// W strict mode: null i undefined to osobne typy
let nothing: null = null;
let notDefined: undefined = undefined;

// Union type - zmienna może być string LUB null
let maybeString: string | null = null;
maybeString = "hello";  // ✓ OK
maybeString = null;     // ✓ OK
// maybeString = 123;   // ❌ Error
