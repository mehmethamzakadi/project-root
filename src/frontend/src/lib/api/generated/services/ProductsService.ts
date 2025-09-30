/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CreateProductRequest } from '../models/CreateProductRequest';
import type { ProductDto } from '../models/ProductDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class ProductsService {
    /**
     * @param page
     * @param pageSize
     * @returns any Success
     * @throws ApiError
     */
    public static getProducts(
        page: number,
        pageSize: number,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/products',
            query: {
                'page': page,
                'pageSize': pageSize,
            },
        });
    }
    /**
     * @param requestBody
     * @returns ProductDto Created
     * @throws ApiError
     */
    public static createProduct(
        requestBody: CreateProductRequest,
    ): CancelablePromise<ProductDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/products',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
            },
        });
    }
    /**
     * @param id
     * @returns ProductDto Success
     * @throws ApiError
     */
    public static getProductById(
        id: string,
    ): CancelablePromise<ProductDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/products/{id}',
            path: {
                'id': id,
            },
            errors: {
                404: `Not Found`,
            },
        });
    }
}
