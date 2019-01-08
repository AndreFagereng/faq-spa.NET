import { Answer } from "./Answer";

//Question class
export class Questions {
  QID: number;
  Question: string;
  Qtype: QEnumType;
  Answer: Answer; 
  Upvotes: number;
  Downvotes: number;
}

//Uses Enum to set the appropriate question-type.
export enum QEnumType {
  Account = "Account",
  Payments = "Payments",
  Delivery = "Delivery",
  Customer = "Customer"
}

