export default interface Post {
  id: string;
  authorId: string;
  text: string;
  location: { longitude: number; latitude: number };
}
