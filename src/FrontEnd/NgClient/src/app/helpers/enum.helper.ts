export function enumValues(e: Object): any[]{
    const mas = Object.values(e);
    return mas.splice(mas.length / 2, mas.length);
}