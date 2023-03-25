export default interface Post {
  id?: string;
  authorId?: string;
  authorName?: string;
  text: string;
  location: { longitude: number; latitude: number };
}
