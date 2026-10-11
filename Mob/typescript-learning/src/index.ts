// Typowana funkcja powitania
/*
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

// ========== SPOSÓB 1: Type[] ==========
let numbers: number[] = [1, 2, 3, 4, 5];
let names: string[] = ["Anna", "Piotr", "Kasia"];

// Metody tablicy są typowane!
numbers.push(6);        // ✓ OK
// numbers.push("7");   // ❌ Error: Argument of type 'string'...

// Dostęp do elementów
console.log(numbers[0]);  // 1 (typ: number)


// ========== SPOSÓB 2: Array<Type> (Generic) ==========
let scores: Array<number> = [90, 85, 88, 92];
let cities: Array<string> = ["Warszawa", "Kraków", "Gdańsk"];


// ========== TABLICE MIESZANE (Union Type) ==========
let mixed: (string | number)[] = ["Anna", 25, "Piotr", 30];
mixed.push("Kasia");  // ✓ OK
mixed.push(35);       // ✓ OK
// mixed.push(true);  // ❌ Error: boolean nie jest w union


// Tuple: dokładnie 2 elementy [string, number]
let person: [string, number];
person = ["Anna", 25];  // ✓ OK - string na pozycji 0, number na pozycji 1

// ❌ Błędy:
// person = [25, "Anna"];        // Zła kolejność typów
// person = ["Anna"];            // Za mało elementów
// person = ["Anna", 25, true];  // Za dużo elementów

// Dostęp do elementów (TypeScript wie jaki typ!)
let name = person[0];  // typ: string
let age2 = person[1];   // typ: number

// Destrukturyzacja
let [personName, personAge] = person;
console.log(personName);  // "Anna"
console.log(personAge);   // 25


// ========== TUPLE Z OPCJONALNYMI ELEMENTAMI ==========
let coordinate: [number, number, number?];  // z opcjonalne
coordinate = [10, 20];       // ✓ OK
coordinate = [10, 20, 30];   // ✓ OK


// ========== NAMED TUPLES (TS 4.0+) ==========
type Point = [x: number, y: number];
const point: Point = [100, 200];


enum Direction {
  Up,       // 0
  Down,     // 1
  Left,     // 2
  Right     // 3
}

let playerDirection: Direction = Direction.Up;
console.log(playerDirection);  // 0

// Porównanie
if (playerDirection === Direction.Up) {
  console.log("Idzie w górę!");
}

enum Status {
  Active = 1,
  Inactive = 0,
  Pending = 2,
  Deleted = -1
}

let userStatus: Status = Status.Active;
console.log(userStatus);  // 1

// Lepsze do debugowania i logów!
enum Color {
  Red = "RED",
  Green = "GREEN",
  Blue = "BLUE"
}

let favoriteColor: Color = Color.Red;
console.log(favoriteColor);  // "RED" - czytelne w logach!

// Często używane w API
enum HttpStatus {
  OK = "200",
  Created = "201",
  BadRequest = "400",
  NotFound = "404",
  InternalServerError = "500"
}

//Any (Dowolny typ)
// ⚠️ ANY = wyłącza sprawdzanie typów - UNIKAJ!

let anything: any = "hello";
anything.toUpperCase(); // ✓ OK w kompilacji, ale może crashować!
anything = 42;          // ✓ OK
anything = true;        // ✓ OK
anything = { x: 1 };    // ✓ OK

// Użyj TYLKO gdy:
// - Migrujesz z JS do TS (tymczasowo)
// - Integrujesz z biblioteką bez typów
// - Prototypujesz (i zamienisz na prawdziwy typ)

// Unknown 
// Unknown to bezpieczna wersja any. 
// Możesz do niej przypisać cokolwiek, ale żeby użyć wartości - 
// musisz SPRAWDZIĆ jej typ.

let userInput: unknown;
userInput = "hello";
userInput = 123;

// ❌ Nie możesz od razu użyć:
// let text: string = userInput;
// Error: Type 'unknown' is not assignable to type 'string'

// ✅ Musisz sprawdzić typ (Type Guard):
if (typeof userInput === "string") {
  let text: string = userInput;  // ✓ OK - TypeScript wie że to string
  console.log(text.toUpperCase());
}

if (typeof userInput === "number") {
  let num: number = userInput;   // ✓ OK
  console.log(num * 2);
}

// Funkcja która nic nie zwraca
function logMessage(message: string): void {
  console.log(message);
  // brak 'return' lub 'return;' bez wartości
}

logMessage("Hello TypeScript!");

// void możesz przypisać tylko undefined
let result: void = undefined;

// Funkcja która wyrzuca błąd (nigdy nie zwraca)
function throwError(message: string): never {
  throw new Error(message);
}

// Funkcja z nieskończoną pętlą
function infiniteLoop(): never {
  while (true) {
    console.log("Looping...");
  }
}

// Użycie w exhaustiveness checking (switch)
type Shape = "circle" | "square" | "triangle";

function getArea(shape: Shape): number {
  switch (shape) {
    case "circle":
      return 3.14;
    case "square":
      return 1;
    case "triangle":
      return 0.5;
    default:
      // Jeśli dodasz nowy shape, a nie obsłużysz go wyżej
      // TypeScript pokaże błąd tutaj!
      const _exhaustive: never = shape;
      return _exhaustive;
  }
}


///Funkcje:
// ========== ZWYKŁA FUNKCJA ==========
function add(a: number, b: number): number {
  return a + b;
}

// ========== ARROW FUNCTION ==========
const multiply = (a: number, b: number): number => {
  return a * b;
};

// Skrócony zapis (implicit return)
const divide = (a: number, b: number): number => a / b;

// ========== INFERENCJA TYPU ZWRACANEGO ==========
// TypeScript sam wywnioskuje że zwracamy number
const subtract = (a: number, b: number) => a - b;

// Użycie
console.log(add(5, 3));       // 8
console.log(multiply(5, 3));  // 15
console.log(divide(15, 3));   // 5
*/
/*
// Parametr opcjonalny oznaczamy ? (musi być na końcu!)
function greet(name: string, greeting?: string): string {
  if (greeting !== undefined) {
    return `${greeting}, ${name}!`;
  }
  return `Cześć, ${name}!`;
}

console.log(greet("Anna"));           // "Cześć, Anna!"
console.log(greet("Piotr", "Witaj")); // "Witaj, Piotr!"

// Wiele opcjonalnych parametrów
function createUser(
  name: string,
  age?: number,
  email?: string
): string {
  let result = `User: ${name}`;
  if (age) result += `, Age: ${age}`;
  if (email) result += `, Email: ${email}`;
  return result;
}

// Parametr domyślny - użyty gdy nie przekazano wartości
function introduce(name: string, age: number = 18): string {
  return `${name} ma ${age} lat`;
}

console.log(introduce("Kasia"));        // "Kasia ma 18 lat"
console.log(introduce("Marek", 30));    // "Marek ma 30 lat"

// Domyślna wartość może być wyrażeniem
function createId(prefix: string = "ID", timestamp: number = Date.now()): string {
  return `${prefix}-${timestamp}`;
}

// Rest parameter - przyjmuje dowolną liczbę argumentów jako tablicę
function sum(...numbers: number[]): number {
  return numbers.reduce((total, n) => total + n, 0);
}

console.log(sum(1, 2, 3));           // 6
console.log(sum(10, 20, 30, 40));    // 100
console.log(sum());                   // 0

// Można łączyć z innymi parametrami
function logItems(prefix: string, ...items: string[]): void {
  items.forEach(item => console.log(`${prefix}: ${item}`));
}

logItems("TODO", "Kupić mleko", "Zadzwonić do mamy", "Nauczyć się TS");

// Deklaracja typu funkcji
let calculate: (x: number, y: number) => number;

// Przypisanie różnych funkcji o tej samej sygnaturze
calculate = (a, b) => a + b;
console.log(calculate(5, 3));  // 8

calculate = (a, b) => a * b;
console.log(calculate(5, 3));  // 15

calculate = (a, b) => a - b;
console.log(calculate(5, 3));  // 2


// ========== CALLBACK JAKO PARAMETR ==========
function processNumbers(
  nums: number[],
  callback: (n: number) => number
): number[] {
  return nums.map(callback);
}

const doubled = processNumbers([1, 2, 3], n => n * 2);
console.log(doubled);  // [2, 4, 6]

const squared = processNumbers([1, 2, 3], n => n * n);
console.log(squared);  // [1, 4, 9]


// Definicja interfejsu
interface User {
  id: number;
  name: string;
  email: string;
  isActive: boolean;
}

// Użycie - obiekt MUSI mieć wszystkie pola
const user1: User = {
  id: 1,
  name: "Anna Kowalska",
  email: "anna@example.com",
  isActive: true
};

console.log(user1.name);  // "Anna Kowalska"

// ❌ Błąd - brakuje pola
// const user2: User = {
//   id: 2,
//   name: "Piotr"
// };
// Error: Property 'email' is missing in type...

// ❌ Błąd - nadmiarowe pole
// const user3: User = {
//   id: 3,
//   name: "Kasia",
//   email: "kasia@example.com",
//   isActive: true,
//   age: 25  // Error: 'age' does not exist in type 'User'
// };

interface Product {
  id: number;
  name: string;
  description?: string;  // Opcjonalne - może być undefined
  price: number;
}

// OK - bez description
const product1: Product = {
  id: 1,
  name: "Laptop",
  price: 3000
};

// OK - z description
const product2: Product = {
  id: 2,
  name: "Monitor",
  description: "24 cale Full HD",
  price: 800
};

interface Config {
  readonly apiUrl: string;
  readonly timeout: number;
}

const config: Config = {
  apiUrl: "https://api.example.com",
  timeout: 5000
};

// ❌ Nie można zmienić readonly
// config.apiUrl = "https://new-url.com";
// Error: Cannot assign to 'apiUrl' because it is a read-only property

interface Calculator {
  add(a: number, b: number): number;
  subtract(a: number, b: number): number;
  multiply(a: number, b: number): number;
  divide(a: number, b: number): number;
}

const calc: Calculator = {
  add: (a, b) => a + b,
  subtract: (a, b) => a - b,
  multiply: (a, b) => a * b,
  divide: (a, b) => a / b
};

console.log(calc.add(10, 5));      // 15
console.log(calc.subtract(10, 5)); // 5
console.log(calc.multiply(10, 5)); // 50
console.log(calc.divide(10, 5));   // 2

// Interfejs bazowy
interface Person {
  name: string;
  age: number;
}

// Rozszerzenie - Employee ma wszystko z Person + dodatkowe pola
interface Employee extends Person {
  companyName: string;
  salary: number;
  department: string;
}

const employee: Employee = {
  name: "Jan Nowak",
  age: 30,
  companyName: "Tech Corp",
  salary: 8000,
  department: "IT"
};

// Wielokrotne rozszerzenie
interface Manager extends Employee {
  teamSize: number;
  isExecutive: boolean;
}

// ========== TYPE ALIAS DLA PROSTEGO TYPU ==========
type ID = number;
let userId: ID = 123;

// ========== TYPE ALIAS DLA OBIEKTU ==========
type Point = {
  x: number;
  y: number;
};

const point: Point = { x: 10, y: 20 };

// ========== UNION TYPES (tylko type, nie interface!) ==========
type StringOrNumber = string | number;

let value: StringOrNumber;
value = "hello";  // ✓ OK
value = 42;       // ✓ OK
// value = true;  // ❌ Error

// ========== LITERAL TYPES ==========
type Status = "active" | "inactive" | "pending";

let userStatus: Status;
userStatus = "active";   // ✓ OK
userStatus = "pending";  // ✓ OK
// userStatus = "deleted"; // ❌ Error: Type '"deleted"' is not assignable

// ┌─────────────────────────────────────────────────────────────┐
// │              INTERFACE vs TYPE ALIAS                         │
// ├─────────────────────────────────────────────────────────────┤
// │                                                              │
// │  INTERFACE                      TYPE ALIAS                   │
// │  ──────────                     ──────────                   │
// │  • Rozszerzanie: extends        • Rozszerzanie: &            │
// │  • Declaration merging          • Brak mergingu              │
// │  • Tylko dla obiektów           • Dla wszystkiego            │
// │  • Preferowane dla API          • Preferowane dla union      │
// │                                                              │
// │  Przykład rozszerzania:                                      │
// │                                                              │
// │  interface A { x: number }      type A = { x: number }       │
// │  interface B extends A {        type B = A & {               │
// │    y: number                      y: number                  │
// │  }                              }                            │
// │                                                              │
// │  Użyj interface gdy:            Użyj type gdy:               │
// │  • Definiujesz kształt obiektu  • Potrzebujesz union types  │
// │  • Tworzysz publiczne API       • Potrzebujesz tuple        │
// │  • Chcesz rozszerzać            • Potrzebujesz mapped types │
// │                                                              │
// └─────────────────────────────────────────────────────────────┘

*//*
class Person {
  // Pola klasy
  name: string;
  age: number;

  // Konstruktor - wywoływany przy tworzeniu instancji
  constructor(name: string, age: number) {
    this.name = name;
    this.age = age;
  }

  // Metoda
  greet(): string {
    return `Cześć, jestem ${this.name}`;
  }

  // Metoda z parametrem
  celebrateBirthday(ileLat :number = 1): void {
    this.age += ileLat;
    console.log(`${this.name} ma teraz ${this.age} lat!`);
  }
}

// Tworzenie instancji
const person1 = new Person("Anna", 25);
console.log(person1.greet());        // "Cześć, jestem Anna"
person1.celebrateBirthday();         // "Anna ma teraz 26 lat!"
 
class BankAccount {
  // PUBLIC - dostępne wszędzie (domyślne)
  public accountNumber: string;
  
  // PRIVATE - dostępne TYLKO wewnątrz tej klasy
  private balance: number;
  
  // PROTECTED - dostępne w klasie i klasach dziedziczących
  protected owner: string;

  constructor(accountNumber: string, initialBalance: number, owner: string) {
    this.accountNumber = accountNumber;
    this.balance = initialBalance;
    this.owner = owner;
  }

  // Publiczna metoda - może być wywołana z zewnątrz
  public getBalance(): number {
    return this.balance;
  }

  // Prywatna metoda - tylko wewnętrznie
  private calculateInterest(): number {
    return this.balance * 0.05;
  }

  // Publiczna metoda używająca prywatnej
  public deposit(amount: number): void {
    if (amount > 0) {
      this.balance += amount;
    }
  }

  public withdraw(amount: number): boolean {
    if (amount > 0 && amount <= this.balance) {
      this.balance -= amount;
      return true;
    }
    return false;
  }
}

const account = new BankAccount("123456", 1000, "Jan");

// ✓ Dostęp do public
console.log(account.accountNumber);  // "123456"
console.log(account.getBalance());   // 1000

// ❌ Brak dostępu do private
// console.log(account.balance);
// Error: Property 'balance' is private

// ❌ Brak dostępu do protected (z zewnątrz)
// console.log(account.owner);
// Error: Property 'owner' is protected

// ❌ Długi zapis (tradycyjny)
class UserLong {
  name: string;
  email: string;
  age: number;

  constructor(name: string, email: string, age: number) {
    this.name = name;
    this.email = email;
    this.age = age;
  }
}

// ✅ Skrócony zapis - parametry z modyfikatorem
class UserShort {
  constructor(
    public name: string,
    public email: string,
    public age: number
  ) {}
  // TypeScript automatycznie tworzy pola i przypisuje wartości!
}

const user = new UserShort("Anna", "anna@example.com", 25);
console.log(user.name);   // "Anna"
console.log(user.email);  // "anna@example.com"
console.log(user.age);    // 25


class Animal {
  constructor(public name: string) {}

  move(): void {
    console.log(`${this.name} się porusza`);
  }
}

class Dog extends Animal {
  constructor(name: string, public breed: string) {
    super(name);  // Wywołanie konstruktora rodzica
  }

  // Nadpisanie metody
  move(): void {
    console.log(`${this.name} biega!`);
  }

  // Nowa metoda
  bark(): void {
    console.log(`${this.name} szczeka: Hau hau!`);
  }
}

const dog = new Dog("Burek", "Labrador");
dog.move();  // "Burek biega!"
dog.bark();  // "Burek szczeka: Hau hau!"


// ❌ BEZ generics - duplikacja kodu
function getFirstString(arr: string[]): string | undefined {
  return arr[0];
}

function getFirstNumber(arr: number[]): number | undefined {
  return arr[0];
}

// ✅ Z generics - jedna funkcja dla wszystkich typów
function getFirst<T>(arr: T[]): T | undefined {
  return arr[0];
}

// TypeScript wnioskuje typ z argumentu
const firstNum = getFirst([1, 2, 3]);      // typ: number | undefined
const firstStr = getFirst(["a", "b"]);     // typ: string | undefined
const firstBool = getFirst([true, false]); // typ: boolean | undefined

// Lub jawne podanie typu
const first = getFirst<number>([1, 2, 3]); // typ: number | undefined

// ❌ Błąd typów - próba mieszania typów
//const firstNumError = getFirst<number>([1, 2, 3, "69"]);  
//const firstNumError = getFirst([1, 2, 3, "69"]);   nie ma bledu - inferencja

// Funkcja identity - zwraca to co dostanie
function identity<T>(arg: T): T {
  return arg;
}

let output1 = identity("hello");  // string
let output2 = identity(42);       // number
let output3 = identity(true);     // boolean

// Funkcja swap - zamienia elementy tuple
function swap<T, U>(tuple: [T, U]): [U, T] {
  return [tuple[1], tuple[0]];
}

const result = swap([1, "hello"]);  // [string, number] = ["hello", 1]
console.log(result);  // ["hello", 1]

// Interfejs "pudełka" na dowolny typ
interface Box<T> {
  content: T;
  label: string;
}

const stringBox: Box<string> = {
  content: "Hello",
  label: "Greeting"
};

const numberBox: Box<number> = {
  content: 42,
  label: "The Answer"
};

const userBox: Box<{ name: string; age: number }> = {
  content: { name: "Anna", age: 25 },
  label: "User Data"
};

// ❌ Błąd typów - label powinien być string, nie number
// const userBoxerr: Box<{ name: string; age: number }> = {
//   content: { name: "Anna", age: 25 },
//   label: 69
// };

// ========== ODPOWIEDŹ API ==========
interface ApiResponse<T> {
  data: T;
  status: number;
  message: string;
}

// Użycie z różnymi typami danych
interface User {
  id: number;
  name: string;
}

interface Product {
  id: number;
  name: string;
  price: number;
}

const userResponse: ApiResponse<User> = {
  data: { id: 1, name: "Anna" },
  status: 200,
  message: "Success"
};

const productsResponse: ApiResponse<Product[]> = {
  data: [
    { id: 1, name: "Laptop", price: 3000 },
    { id: 2, name: "Phone", price: 2000 }
  ],
  status: 200,
  message: "Success"
};

class DataStorage<T> {
  private data: T[] = [];

  addItem(item: T): void {
    this.data.push(item);
  }

  removeItem(item: T): void {
    const index = this.data.indexOf(item);
    if (index !== -1) {
      this.data.splice(index, 1);
    }
  }

  getItems(): T[] {
    return [...this.data];  // Zwraca kopię
  }

  getItem(index: number): T | undefined {
    return this.data[index];
  }
}

// Storage dla liczb
const numberStorage = new DataStorage<number>();
numberStorage.addItem(10);
numberStorage.addItem(20);
numberStorage.addItem(30);
console.log(numberStorage.getItems());  // [10, 20, 30]

// Storage dla stringów
const textStorage = new DataStorage<string>();
textStorage.addItem("Hello");
textStorage.addItem("World");
console.log(textStorage.getItems());  // ["Hello", "World"]

// Ograniczenie: T musi mieć property 'length'
interface Lengthwise {
  length: number;
}

function logLength<T extends Lengthwise>(arg: T): void {
  console.log(`Length: ${arg.length}`);
}

logLength("Hello");           // ✓ OK - string ma length
logLength([1, 2, 3]);         // ✓ OK - array ma length
logLength({ length: 10 });    // ✓ OK - obiekt z length

// logLength(123);            // ❌ Error - number nie ma length

// ========== KEYOF CONSTRAINT ==========
function getProperty<T, K extends keyof T>(obj: T, key: K): T[K] {
  return obj[key];
}

const person = { name: "Anna", age: 25, city: "Warsaw" };

const name = getProperty(person, "name");  // string
console.log("imie: ", name); // "Anna"
const age = getProperty(person, "age");    // number
console.log("wiek: ", age); // 25
const city = getProperty(person, "city");    // string
console.log("miasto: ", city); // "Warsaw"
// getProperty(person, "job");  // ❌ Error: "job" nie istnieje w person
*/
//Utility types

//Partial
//Wszystkie pola stają się opcjonalne.

interface User {
  id: number;
  name: string;
  email: string;
  age: number;
}

// Partial<User> = wszystkie pola opcjonalne
function updateUser(id: number, updates: Partial<User>): void {
  console.log(`Aktualizuję użytkownika ${id}:`, updates);
}

// Możesz przekazać dowolny podzbiór pól
updateUser(1, { name: "Nowa nazwa" });
updateUser(2, { email: "new@example.com", age: 30 });
updateUser(3, {});  // Nawet pusty obiekt OK

interface Config {
  apiUrl?: string;
  timeout?: number;
  debug?: boolean;
}

// Required<Config> = wszystkie pola wymagane
const fullConfig: Required<Config> = {
  apiUrl: "https://api.com",
  timeout: 5000,
  debug: true
};

// Musisz podać wszystkie pola!
// const incompleteConfig: Required<Config> = {
//   apiUrl: "https://api.com"
// }; // ❌ Error - brak timeout i debug

interface User {
  id: number;
  name: string;
  email: string;
  password: string;
  createdAt: Date;
}

// Wybierz tylko id i name
type UserPreview = Pick<User, "id" | "name">;

const preview: UserPreview = {
  id: 1,
  name: "Anna"
  // Nie możesz dodać innych pól!
};
/*
// Wyklucz password z User
type UserWithoutPassword = Omit<User, "password">;

const safeUser: UserWithoutPassword = {
  id: 1,
  name: "Anna",
  email: "anna@example.com",
  createdAt: new Date()
  // password nie istnieje!
};

// Często używane przy wysyłaniu danych do klienta
type PublicUser = Omit<User, "password" | "createdAt">;

const publicUser: PublicUser = {
  id: 1,
  name: "Anna",
  email: "anna@example.com"
  // password i createdAt nie istnieją!
};*/
//Record<K, V>
// Obiekt z kluczami typu K i wartościami typu V.

// Mapa statusów

type AgelessUser = Omit<User, "age">;
type Status = "pending" | "approved" | "rejected";

const statusLabels: Record<Status, string> = {
  pending: "Oczekujący",
  approved: "Zatwierdzony",
  rejected: "Odrzucony"
};

// Mapa użytkowników po ID
type UsersById = Record<number, AgelessUser>;

const users: UsersById = {
  1: { id: 1, name: "Anna", email: "a@a.com", password: "xxx", createdAt: new Date() },
  2: { id: 2, name: "Piotr", email: "p@p.com", password: "xxx", createdAt: new Date() }
};


interface Settings {
  theme: string;
  language: string;
}

const settings: Readonly<Settings> = {
  theme: "dark",
  language: "pl"
};

// settings.theme = "light";  // ❌ Error: Cannot assign to 'theme'