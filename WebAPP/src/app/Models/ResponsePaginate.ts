export class ResponsePaginate<T> {
    total?: number;
    page?: number;
    limit?: number;
    data?: T
}