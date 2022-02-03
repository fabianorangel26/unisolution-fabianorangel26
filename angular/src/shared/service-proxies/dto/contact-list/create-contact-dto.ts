export interface ICreateContactDto {
    id: number;
    personId: number;
    name: string;
    telephone: string;
    email: string;
    isActive: boolean;
}

export class CreateContactDto implements ICreateContactDto {
    id: number;
    personId: number;
    name: string;
    telephone: string;
    email: string;
    isActive: boolean;

    constructor(data?: ICreateContactDto) {
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
            this.personId = data.personId;
            this.name = data.name;
            this.telephone = data.telephone;
            this.email = data.email;
            this.isActive = data.isActive;
        }
    }

    static fromJS(data: any): CreateContactDto {
        data = typeof data === "object" ? data : {};
        let result = new CreateContactDto();
        result.init(data);

        return result;
    }

    toJSON(data?: any) {
        data = typeof data === "object" ? data : {};
        data.id = this.id;
        data.personId = this.personId;
        data.name = this.name;
        data.telephone = this.telephone;
        data.email = this.email;
        data.isActive = this.isActive;

        return data;
    }
}
