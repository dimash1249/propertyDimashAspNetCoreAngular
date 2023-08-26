import { News } from "../news/news";
import { Property } from "../property/property";

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: boolean;
  passwordHash: string;
  securityStamp: string;
  concurrencyStamp: string;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd: Date;
  lockoutEnabled: boolean;
  accessFailedCount: number;
  news: News[];
  properties: Property[];
}

export interface UserRegistration {
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  password: string;
  confirmPassword: string;
}

export interface UserLogin {
  userName: string;
  password: string;
}
