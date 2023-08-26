import { User } from "../user/user";

export interface News {
  id: string;
  title: string;
  description: string;
  imageAuthor: string;
  imageNews: string;
  newsType: string;
  publishedDate: string;
  user: User;
  userId: string;
}
