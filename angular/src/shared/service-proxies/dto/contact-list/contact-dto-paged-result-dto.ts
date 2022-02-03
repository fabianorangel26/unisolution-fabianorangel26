import { ContactDto } from "./contact-dto";

export interface IContactDtoPagedResultDto {
    totalCount: number;
    items: ContactDto[] | undefined;
}

export class ContactDtoPagedResultDto implements IContactDtoPagedResultDto {
    totalCount: number;
    items: ContactDto[] | undefined;

    constructor(data?: IContactDtoPagedResultDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (Array.isArray(data["items"])) {
                this.items = [] as any;
                for (let item of data["items"])
                    this.items.push(ContactDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): ContactDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new ContactDtoPagedResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone(): ContactDtoPagedResultDto {
        const json = this.toJSON();
        let result = new ContactDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
