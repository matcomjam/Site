import { User } from './user.model';
import { Comment } from './comment.model';

export class Blog {
    Id: Number;
    Title: String;
    Description: String;
    Resume: String;
    UserId: Number;
    UserName: String;
    Comments: Comment[];
}