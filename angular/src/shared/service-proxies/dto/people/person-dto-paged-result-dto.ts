import { PersonDto } from "./person-dto";

export interface IPersonDtoPagedResultDto {
    totalCount: number;
    items: PersonDto[] | undefined;
}

export class PersonDtoPagedResultDto implements IPersonDtoPagedResultDto {
    totalCount: number;
    items: PersonDto[] | undefined;

    constructor(data?: IPersonDtoPagedResultDto) {
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
                    this.items.push(PersonDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PersonDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new PersonDtoPagedResultDto();
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

    clone(): PersonDtoPagedResultDto {
        const json = this.toJSON();
        let result = new PersonDtoPagedResultDto();
        result.init(json);
        return result;
    }
}
