export class BookParams {
    constructor(bookId, userId){
        this.bookId = bookId;
        this.userId = userId;
    }
    bookId: string|number;
    userId: number|string;
}