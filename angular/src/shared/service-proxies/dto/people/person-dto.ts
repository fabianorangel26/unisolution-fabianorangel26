export interface IPersonDto {
    id: number;
    name: string;
    documentType: string;
    document: string;
    isActive: boolean;
}

export class PersonDto implements IPersonDto {
    id: number;
    name: string;
    documentType: string;
    document: string;
    isActive: boolean;

    constructor(data?: IPersonDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data.id;
            this.name = data.name;
            this.documentType = data.documentType;
            this.document = data.document;
            this.isActive = data.isActive;
        }
    }

    static fromJS(data: any): PersonDto {
        data = typeof data === "object" ? data : {};
        let result = new PersonDto();
        result.init(data);

        return result;
    }

    toJSON(data?: any) {
        data = typeof data === "object" ? data : {};
        data.id = this.id;
        data.name = this.name;
        data.documentType = this.documentType;
        data.document = this.document;
        data.isActive = this.isActive;

        return data;
    }
}
