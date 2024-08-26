import { Camera } from "./camera";

export interface CameraResponse {
    value: {
      value: DivideCameras;
      isSuccess: boolean;
      isFailure: boolean;
      error: {
        code: string;
        name: string;
      };
    };
    statusCode: number;
    contentType: string | null;
  }

export interface DivideCameras {
    dividedByThree: Camera[];
    dividedByFive: Camera[];
    dividedByThreeAndFive: Camera[];
    undivided: Camera[];
}