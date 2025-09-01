export interface ApiErrorDetails {
  code: string;
  description: string;
  type: number;
}

export interface ApiError {
  type: string;
  title: string;
  status: number;
  detail: string;
  errors?: ApiErrorDetails[];
}
