export interface IContactDto {
    id: string;
    name: string;
    telephone: string;
    email: string;
    isActive: boolean;
}

export class ContactDto implements IContactDto {
    id: string;
    name: string;
    telephone: string;
    email: string;
    isActive: boolean;

    constructor(data?: IContactDto) {
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
            this.telephone = data.telephone;
            this.email = data.email;
            this.isActive = data.isActive;
        }
    }

    static fromJS(data: any): ContactDto {
        data = typeof data === "object" ? data : {};
        let result = new ContactDto();
        result.init(data);

        return result;
    }

    toJSON(data?: any) {
        data = typeof data === "object" ? data : {};
        data.id = this.id;
        data.name = this.name;
        data.telephone = this.telephone;
        data.email = this.email;
        data.isActive = this.isActive;

        return data;
    }
}
