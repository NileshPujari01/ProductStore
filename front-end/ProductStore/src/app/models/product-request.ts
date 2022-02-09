export class ProductRequest {
    productRequest!: ProductApiRequest;
}

export class ProductApiRequest {
    productId!: number;
    productName!: string;
    productCategory!: number;
    productPrice!: string;
    productRating!: number;
}