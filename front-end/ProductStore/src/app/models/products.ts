export class Products {
    products!: Array<ProductItems>;
}

export class ProductItems {
    productId!: number;
    productName!: string;
    productCategory!: number;
    productPrice!: string;
    productRating!: number;
    productImage!: string;
    productCategoryName!: string;
}